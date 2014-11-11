//
//  ViewCreatePromoController.m
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "ViewCreatePromoController.h"
#import <Parse/Parse.h>
#import <GoogleMaps/GoogleMaps.h>
#import "CoreDataHelper.h"
#import "CorePromotion.h"
#import "Promotion.h"

@interface ViewCreatePromoController ()
{
    NSArray *pickerData;
    CLLocationManager *locationManager;
    
}

@property(nonatomic, strong) CoreDataHelper* cdHelper;

@end

@implementation ViewCreatePromoController

- (void)viewDidLoad {
    
    self.view.backgroundColor=[UIColor colorWithPatternImage:[UIImage imageNamed:@"17.1.jpg"]];
    
    [super viewDidLoad];
    
    // Add categories
    pickerData = @[@"Animals", @"White technic", @"Clothes", @"Cars", @"Food", @"Things for home", @"Culture", @"For the kids", @"For the family", @"Cosmetics", @"Computers", @"Smart Phones", @"Photography",@"Fun", @"Chalga", @"Other"];
    
    // Connect data
    self.picker.dataSource = self;
    self.picker.delegate = self;
    
    // add long press gesture
    UILongPressGestureRecognizer *longPress = [[UILongPressGestureRecognizer alloc]
                                               initWithTarget:self
                                               action:@selector(handleLongPress:)];
    longPress.minimumPressDuration = 1.0;
    [self.view addGestureRecognizer:longPress];
    
    //Core data
    _cdHelper = [[CoreDataHelper alloc] init];
    [_cdHelper setupCoreData];
}

-(void)handleLongPress:(UILongPressGestureRecognizer*)recognizer{
    if (recognizer.state == UIGestureRecognizerStateEnded) {
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Here camera opens and you make picture" message:@"Picture successfully added." delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
        [alert show];
    }
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

//For the picker
// The number of columns of data
- (NSInteger)numberOfComponentsInPickerView:(UIPickerView *)pickerView
{
    return 1;
}

// The number of rows of data
- (NSInteger)pickerView:(UIPickerView *)pickerView numberOfRowsInComponent:(NSInteger)component
{
    return pickerData.count;
}

// The data to return for the row and component (column) that's being passed in
- (NSString*)pickerView:(UIPickerView *)pickerView titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    return pickerData[row];
}


- (IBAction)createPromo:(id)sender{
    
    [self checkInternet:^(BOOL internet)
     {
         if (internet)
         {
             NSInteger row;
             row = [self.picker selectedRowInComponent:0];
             self.strPrintRepeat = [pickerData objectAtIndex:row];
             
             //take info from the input fields
             NSString *name = self.nameInput.text;
             NSString *info = self.moreInfoInput.text;
             NSString *category = self.strPrintRepeat;
             double price = self.priceInput.text.doubleValue;
             NSNumber *priceNumber = [NSNumber numberWithDouble:price];
             PFGeoPoint *point = [[PFGeoPoint alloc]init];
             
             point.latitude = self.latitudeCreate;
             point.longitude = self.longitudeCreate;
             
             //Validate input info
             if(name == nil || name.length <3 || name.length>=30)
             {
                 UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Invalid name." message:@"It should be between 3 and 30 characters long." delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
                 [alert show];
                 self.nameInput.text = @"";
             }
             else if(price <= 0)
             {
                 UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Invalid price." message:@"It should be a positive number." delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
                 [alert show];
                 self.priceInput.text = @"";
             }
             else
             {
                 //add in cloud database
                 Promotion *newPromo = [Promotion objectWithClassName:@"Promotion"];
                 newPromo.Name = name;
                 newPromo.Category = category;
                 newPromo.Price = priceNumber;
                 newPromo.MoreInfo = info;
                 newPromo.Shop = point;
                 
                 [newPromo saveInBackground];
                 
                 //add in core data
                 CorePromotion * newCorePromo = [NSEntityDescription insertNewObjectForEntityForName:@"CorePromotion" inManagedObjectContext:_cdHelper.context];
                 newCorePromo.name = name;
                 newCorePromo.category = category;
                 newCorePromo.price = priceNumber;
                 newCorePromo.moreInfo = info;
                 newCorePromo.latitudeCore =[NSNumber numberWithDouble: self.latitudeCreate];
                 newCorePromo.longitudeCore = [NSNumber numberWithDouble:self.longitudeCreate];
                 
                 [_cdHelper.context insertObject:newCorePromo];
                 [self.cdHelper saveContext];
                 
                 UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Your promotion is added successfully!" message:nil delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
                 [alert show];
                 
                 self.nameInput.text = @"";
                 self.priceInput.text = @"";
                 self.moreInfoInput.text = @"";
             }
         }
         else
         {
             UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"New promo can not be added" message:@"You are not connected to the internet" delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
             [alert show];
         }
     }];
}


//Check connection
typedef void(^connection)(BOOL);
- (void)checkInternet:(connection)block
{
    [UIApplication sharedApplication].networkActivityIndicatorVisible = YES;
    
    NSURL *url = [NSURL URLWithString:@"http://www.google.com/"];
    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:url];
    request.HTTPMethod = @"HEAD";
    request.cachePolicy = NSURLRequestReloadIgnoringLocalAndRemoteCacheData;
    request.timeoutInterval = 10.0;
    
    [NSURLConnection sendAsynchronousRequest:request
                                       queue:[NSOperationQueue mainQueue]
                           completionHandler:
     ^(NSURLResponse *response, NSData *data, NSError *connectionError)
     {
         [UIApplication sharedApplication].networkActivityIndicatorVisible = NO;
         block([(NSHTTPURLResponse *)response statusCode] == 200);
     }];
}

@end

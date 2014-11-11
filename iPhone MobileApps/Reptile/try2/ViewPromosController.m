//
//  ViewPromosController.m
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "ViewPromosController.h"
#import <Parse/Parse.h>
#import "ViewPromosFromCategoryController.h"
#import "CoreDataHelper.h"
#import "CorePromotion.h"
#import "ViewSinglePromoController.h"

@interface ViewPromosController ()
{
    NSArray *pickerCategoriesData;
    int  myPromo ; //1 means it is your promo from the core data, 2 means it is a promo from the cloud data
}

@property(nonatomic, strong) CoreDataHelper* cdHelper;

@end

@implementation ViewPromosController


- (void)viewDidLoad {
    self.view.backgroundColor=[UIColor colorWithPatternImage:[UIImage imageNamed:@"13.3.jpg"]];
    
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    // Initialize Data
    pickerCategoriesData = @[@"Animals", @"White technic", @"Clothes", @"Cars", @"Food", @"Things for home", @"Culture", @"For the kids", @"For the family", @"Cosmetics", @"Computers", @"Smart Phones", @"Photography",@"Fun", @"Chalga", @"Other"];
    
    // Connect data
    self.pickerCategories.dataSource = self;
    self.pickerCategories.delegate = self;
    
    //Core data
    _cdHelper = [[CoreDataHelper alloc] init];
    [_cdHelper setupCoreData];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

// The number of columns of data
- (NSInteger)numberOfComponentsInPickerView:(UIPickerView *)pickerView
{
    return 1;
}

// The number of rows of data
- (NSInteger)pickerView:(UIPickerView *)pickerView numberOfRowsInComponent:(NSInteger)component
{
    return pickerCategoriesData.count;
}

// The data to return for the row and component (column) that's being passed in
- (NSString*)pickerView:(UIPickerView *)pickerView titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    return pickerCategoriesData[row];
}


- (IBAction)swipeBackLeftFromCategory:(UIStoryboardSegue *)segue {
    
}

- (IBAction)showAllFromCategory:(id)sender {
    
    [self checkInternet:^(BOOL internet)
     {
         if (internet)
         {
             //  NSString *strPrintRepeat;
             NSInteger row;
             myPromo = 2;
             
             row = [_pickerCategories selectedRowInComponent:0];
             self.strPrintRepeat = [pickerCategoriesData objectAtIndex:row];
             NSString *category = self.strPrintRepeat;
             
             PFQuery *query = [PFQuery queryWithClassName:@"Promotion"];
             [query whereKey:@"Category" equalTo:category];
             [query findObjectsInBackgroundWithBlock:^(NSArray *objects, NSError *error) {
                 if (!error) {
                  //   NSLog(@"Successfully retrieved %lu scores.", (unsigned long)objects.count);
                     
                     [self passData:objects];
                     }
                 else {
                     NSLog(@"Error: %@ %@", error, [error userInfo]);
                 }
             }];
         }
         else
         {
             UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Promos can not be loaded" message:@"You are not connected to the internet" delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
             [alert show];
         }
     }];
    
}


- (IBAction)showMyPromos:(id)sender{
    
    [self checkInternet:^(BOOL internet)
     {
         if (internet)
         {
             myPromo = 1;
             NSFetchRequest *request = [NSFetchRequest fetchRequestWithEntityName:@"CorePromotion"];
             NSArray *fetchedPromos = [_cdHelper.context executeFetchRequest:request error:nil];
             
             if (fetchedPromos.count == 0) {
                 UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"You don`t have any promos" message:nil delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
                 [alert show];
             }
             else
             {
                 [self passData:fetchedPromos];
             }

         }
         else
         {
             UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Promos can not be loaded" message:@"You are not connected to the internet" delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
             [alert show];
         }
     }];
}



-(void) passData:(NSArray *) promosToPass{
    
    UIStoryboard * sb = [UIStoryboard storyboardWithName:@"Main" bundle:[NSBundle mainBundle]];
    ViewPromosFromCategoryController *pfc = [sb instantiateViewControllerWithIdentifier:@"PromosFromCategoryNib"];
    pfc.promosFromTheCategory = [[NSArray alloc] init];
    pfc.promosFromTheCategory = promosToPass;
    pfc.myPromoRecieved = myPromo;
    
    [self presentViewController:pfc animated:YES completion:nil]; 
}


//for Accelerometer
-(BOOL)canBecomeFirstResponder {
    return YES;
}

-(void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];
    [self becomeFirstResponder];
}

- (void)viewWillDisappear:(BOOL)animated {
    [self resignFirstResponder];
    [super viewWillDisappear:animated];
}

- (void)motionEnded:(UIEventSubtype)motion withEvent:(UIEvent *)event
{
    if (motion == UIEventSubtypeMotionShake)
    {
        [self showAllFromCategory:nil];
        NSLog(@"Shaked");
    }
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

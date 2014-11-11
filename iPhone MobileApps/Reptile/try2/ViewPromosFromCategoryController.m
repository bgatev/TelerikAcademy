//
//  ViewPromosFromCategoryController.m
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//
#import "ViewSinglePromoController.h"
#import "ViewPromosFromCategoryController.h"
#import "CorePromotion.h"

@interface ViewPromosFromCategoryController ()
{
    NSArray *pickerData;
}

@end

@implementation ViewPromosFromCategoryController

- (void)viewDidLoad {
    
    NSMutableArray *names = [[NSMutableArray alloc] init];
    self.view.backgroundColor=[UIColor colorWithPatternImage:[UIImage imageNamed:@"13.3.jpg"]];
    [super viewDidLoad];
    
    if (self.myPromoRecieved == 1) {
        for (CorePromotion *item in _promosFromTheCategory) {
            [names addObject:item.name];
        }
        
    }
    else{
        for (id item in _promosFromTheCategory) {
            [names addObject:item[@"Name"]];
        }
        
    }
    
    // Initialize Data
    if (names.count == 0){
        pickerData = @[@"No promos in this category."];
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"No promos in this category." message:@"Please, swipe up to go back." delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil,nil];
        [alert show];
    }
    else
    {
        pickerData = names;
    }
    
    
    // Connect data
    self.picker.dataSource = self;
    self.picker.delegate = self;
    
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
    return pickerData.count;
}

// The data to return for the row and component (column) that's being passed in
- (NSString*)pickerView:(UIPickerView *)pickerView titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    return pickerData[row];
}

- (IBAction)swipeBackLeftToPromosFromCategory:(UIStoryboardSegue *)segue {
    
}


- (IBAction)showSinglePromo:(id)sender {
    
    NSString *singleName;
    NSInteger row;
    row = [_picker selectedRowInComponent:0];
    self.strPrintRepeat = [pickerData objectAtIndex:row];
    
    singleName = self.strPrintRepeat;
    
    UIStoryboard * sb = [UIStoryboard storyboardWithName:@"Main" bundle:[NSBundle mainBundle]];
    ViewSinglePromoController *pfc = [sb instantiateViewControllerWithIdentifier:@"SinglePromoNib"];
    
    pfc.promosFromTheCategorySingle = self.promosFromTheCategory;
    pfc.singleNameInView = singleName;
    pfc.mySinglePromoCode = self.myPromoRecieved;
    
    [self presentViewController:pfc animated:YES completion:nil];
}

@end

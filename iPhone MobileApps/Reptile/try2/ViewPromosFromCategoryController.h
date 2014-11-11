//
//  ViewPromosFromCategoryController.h
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewPromosFromCategoryController :  UIViewController<UIPickerViewDataSource, UIPickerViewDelegate>

@property (nonatomic,strong) NSArray *promosFromTheCategory;

@property (weak, nonatomic) NSString* strPrintRepeat;

@property (weak, nonatomic) IBOutlet UIPickerView *picker;

@property  int  myPromoRecieved;

- (IBAction)showSinglePromo:(id)sender;

- (IBAction)swipeBackLeftToPromosFromCategory:(UIStoryboardSegue *)segue;

@end

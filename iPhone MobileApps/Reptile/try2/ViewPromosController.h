//
//  ViewPromosController.h
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewPromosController : UIViewController<UIPickerViewDataSource, UIPickerViewDelegate>

@property (weak, nonatomic) IBOutlet UIPickerView *pickerCategories;

@property (weak, nonatomic) NSString* strPrintRepeat;

- (IBAction)swipeBackLeftFromCategory:(UIStoryboardSegue *)segue;

- (IBAction)showAllFromCategory:(id)sender;

- (IBAction)showMyPromos:(id)sender;


@end

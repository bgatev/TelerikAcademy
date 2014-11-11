//
//  ViewCreatePromoController.h
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>
#import <GoogleMaps/GoogleMaps.h>
#import <Parse/Parse.h>

@interface ViewCreatePromoController : UIViewController<UIPickerViewDataSource, UIPickerViewDelegate,CLLocationManagerDelegate>

@property (weak, nonatomic) IBOutlet UIPickerView *picker;

@property (weak, nonatomic) IBOutlet UITextField *nameInput;

@property (weak, nonatomic) IBOutlet UITextField *moreInfoInput;

@property (weak, nonatomic) IBOutlet UITextField *priceInput;

@property (weak, nonatomic) NSString* strPrintRepeat;

@property double longitudeCreate;

@property double latitudeCreate;

- (IBAction)createPromo:(id)sender;

//@property (strong, nonatomic) UILongPressGestureRecognizer *addPicture;

@end
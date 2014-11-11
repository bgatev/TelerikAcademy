//
//  ViewSinglePromoController.h
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewSinglePromoController : UIViewController

@property NSArray *promosFromTheCategorySingle;

@property NSString *singleNameInView;

@property (weak, nonatomic) IBOutlet UILabel *nameLabel;

@property (weak, nonatomic) IBOutlet UILabel *categoryLabel;

@property (weak, nonatomic) IBOutlet UILabel *priceLabel;

@property (weak, nonatomic) IBOutlet UILabel *moreInfoLabel;

@property int mySinglePromoCode;

@property UIImage *image;

- (IBAction)handlePinch:(UIPinchGestureRecognizer *)recognizer;

- (IBAction)goBackToSinglePromo:(UIStoryboardSegue *)segue;

//- (IBAction)goToSeeTheShopSegue:(UIStoryboardSegue *)segue;

- (IBAction)showPic:(id)sender;

@end

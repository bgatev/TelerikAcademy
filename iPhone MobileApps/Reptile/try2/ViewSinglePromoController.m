//
//  ViewSinglePromoController.m
//  PrImotsiyaApp
//
//  Created by admin on 10/27/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "ViewSinglePromoController.h"
#import "SinglePromoUIView.h"
#import "CorePromotion.h"
#import <Foundation/Foundation.h>
#import "Promotion.h"
#import "SinglePromoMapViewController.h"

@interface ViewSinglePromoController ()

@property (nonatomic,weak) IBOutlet UIImageView *basketTop;
@property (nonatomic,weak) IBOutlet UIImageView *basketBottom;

@end

@implementation ViewSinglePromoController{
    double shopLat;
    double shopLong;
    
}


- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self loadDNibFile];

    if (self.mySinglePromoCode == 2) {
        for (Promotion *promo in _promosFromTheCategorySingle) {
            BOOL found =[promo.Name isEqualToString:_singleNameInView];
            if (found) {
                self.nameLabel.text = promo.Name;
                self.moreInfoLabel.text = promo.MoreInfo;
                self.categoryLabel.text = promo.Category;
                self.priceLabel.text = [promo.Price stringValue ];
                shopLat = promo.Shop.latitude;
                shopLong = promo.Shop.longitude;
                break;
            }
        }
    }
    else if( self.mySinglePromoCode == 1){
        for (CorePromotion * promo in _promosFromTheCategorySingle) {
            BOOL found =[promo.name isEqualToString:_singleNameInView];
            if (found) {
                self.nameLabel.text = promo.name;
                self.priceLabel.text =[promo.price stringValue];
                self.moreInfoLabel.text = promo.moreInfo;
                self.categoryLabel.text = promo.category;
                shopLat = [promo.latitudeCore doubleValue];
                shopLong = [promo.longitudeCore doubleValue ];
                break;
            }
        }
    }
    
    
    
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

    //Animations
- (void)viewDidAppear:(BOOL)animated
{
    
    CGRect basketTopFrame = self.basketTop.frame;
    basketTopFrame.origin.y = -basketTopFrame.size.height;
    
    CGRect basketBottomFrame = self.basketBottom.frame;
    basketBottomFrame.origin.y = self.view.bounds.size.height;
    
    [UIView beginAnimations:nil context:nil];
    [UIView setAnimationDuration:2.0];
    [UIView setAnimationDelay:1.0];
    [UIView setAnimationCurve:UIViewAnimationCurveEaseOut];
    
    self.basketTop.frame = basketTopFrame;
    self.basketBottom.frame = basketBottomFrame;
    
    [UIView commitAnimations];
}

-(void) loadDNibFile{
    SinglePromoUIView *view = [[[NSBundle mainBundle] loadNibNamed:@"SinglePromoNib" owner:self options:nil] objectAtIndex:0];
    view.backgroundColor=[UIColor colorWithPatternImage:[UIImage imageNamed:@"17.1.jpg"]];
    [self.view addSubview:view];
}

- (IBAction)goBackToSinglePromo:(UIStoryboardSegue *)segue
{
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([[segue identifier] isEqualToString:@"goToSeeTheShopSegue"])
    {
        SinglePromoMapViewController *vc = [segue destinationViewController];
        [vc setPointLatitude:&(shopLat)];
        [vc setPointLongitude:&(shopLong)];
    }
}

- (IBAction)handlePinch:(UIPinchGestureRecognizer *)recognizer {
    recognizer.view.transform = CGAffineTransformScale(recognizer.view.transform, recognizer.scale, recognizer.scale);
    recognizer.scale = 1;
}

- (IBAction)showPic:(id)sender {
    //You need to specify the frame of the view
    UIView *picView = [[UIView alloc] initWithFrame:CGRectMake(5,180,300,300)];
    
    self.image = [UIImage imageNamed:@"slon.png"];
    UIImageView *imageView = [[UIImageView alloc] initWithImage:self.image];
    
    //specify the frame of the imageView in the superview , here it will fill the superview
    imageView.frame = picView.bounds;
    
    // add the imageview to the superview
    [picView addSubview:imageView];
    
    //add the view to the main view
    
    [self.view addSubview:picView];
}

@end

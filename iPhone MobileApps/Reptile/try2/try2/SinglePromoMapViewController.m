//
//  SinglePromoMapViewController.m
//  PrImotsiyaApp
//
//  Created by admin on 11/9/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "ViewMapController.h"
#import <GoogleMaps/GoogleMaps.h>
#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>
#import "ViewCreatePromoController.h"
#import "SinglePromoMapViewController.h"

@interface SinglePromoMapViewController ()

@end

@implementation SinglePromoMapViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [super viewDidLoad];
    
    GMSCameraPosition *camera = [GMSCameraPosition cameraWithLatitude:*(self.pointLatitude)
                                                            longitude:*(self.pointLongitude)
                                                                 zoom:16];
    GMSMapView *mapView = [GMSMapView mapWithFrame:CGRectZero camera:camera];
    
    GMSMarker *marker = [[GMSMarker alloc] init];
    marker.position = camera.target;
    marker.snippet = @"You could find the promo here";
    marker.appearAnimation = kGMSMarkerAnimationPop;
    marker.map = mapView;
    
    //add button
    UIButton *button = [UIButton buttonWithType:UIButtonTypeRoundedRect];
    button.frame = CGRectMake(mapView.bounds.size.width - 110, mapView.bounds.size.height - 30, 100, 20);
    button.autoresizingMask = UIViewAutoresizingFlexibleLeftMargin | UIViewAutoresizingFlexibleTopMargin;
    [button setTitle:@"Back" forState:UIControlStateNormal];
    
    [button addTarget: self
               action: @selector(buttonClicked:)
     forControlEvents: UIControlEventTouchUpInside];
    
    [mapView addSubview:button];
    
    self.view = mapView;
    
}

- (IBAction) buttonClicked: (id)sender
{
    [self performSegueWithIdentifier:@"goBackToSinglePromo" sender:sender];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([[segue identifier] isEqualToString:@"goBackToSinglePromo"])
    {
        // Get reference to the destination view controller
        //    ViewCreatePromoController *vc = [segue destinationViewController];
        
        // Pass any objects to the view controller here, like...
    }
}

@end

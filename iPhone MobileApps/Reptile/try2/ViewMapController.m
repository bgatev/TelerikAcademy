//
//  ViewMapController.m
//  PrImotsiyaApp
//
//  Created by admin on 11/6/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "ViewMapController.h"
#import <GoogleMaps/GoogleMaps.h>
#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>
#import "ViewCreatePromoController.h"


@interface ViewMapController ()

@end

@implementation ViewMapController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    GMSCameraPosition *camera = [GMSCameraPosition cameraWithLatitude:42.7
                                                            longitude:23.3
                                                                 zoom:16];
    GMSMapView *mapView = [GMSMapView mapWithFrame:CGRectZero camera:camera];
    
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
    
    mapView.delegate = self;
    
}

- (IBAction) buttonClicked: (id)sender
{
    [self performSegueWithIdentifier:@"returnFromMapSegue" sender:sender];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)mapView:(GMSMapView *)mapView didLongPressAtCoordinate:(CLLocationCoordinate2D)coordinate

{
    GMSMarker *marker3 = [[GMSMarker alloc] init];
    marker3.position = coordinate;
    marker3.title = @"Promo shop";
    marker3.snippet = @"Here you can find the promo item";
    marker3.map = mapView;
    self.view = mapView;
    
    self.latitudeAddress = marker3.position.latitude;
    self.longitudeAddress = marker3.position.longitude;
    
    NSLog(@"Shop address added.");
}

-(void)buttonAction:(id)sender
{
    [self performSegueWithIdentifier:@"returnFromMapSegue" sender:sender];
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([[segue identifier] isEqualToString:@"returnFromMapSegue"])
    {        ViewCreatePromoController *vc = [segue destinationViewController];

        [vc setLongitudeCreate:self.longitudeAddress];
        [vc setLatitudeCreate:self.latitudeAddress];
    }
}

@end

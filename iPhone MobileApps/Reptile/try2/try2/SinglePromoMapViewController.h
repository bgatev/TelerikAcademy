//
//  SinglePromoMapViewController.h
//  PrImotsiyaApp
//
//  Created by admin on 11/9/14.
//  Copyright (c) 2014 admin. All rights reserved.
//
#import <CoreLocation/CoreLocation.h>
#import <GoogleMaps/GoogleMaps.h>
#import <UIKit/UIKit.h>
#import <Parse/Parse.h>

@interface SinglePromoMapViewController :  UIViewController<CLLocationManagerDelegate,GMSMapViewDelegate>

@property double *pointLongitude;

@property double *pointLatitude;

@end

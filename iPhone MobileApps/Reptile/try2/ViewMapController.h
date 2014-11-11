//
//  ViewMapController.h
//  PrImotsiyaApp
//
//  Created by admin on 11/6/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>
#import <GoogleMaps/GoogleMaps.h>
#import <Parse/Parse.h>

@interface ViewMapController : UIViewController<CLLocationManagerDelegate,GMSMapViewDelegate>

@property PFGeoPoint *pointMarker;

@property double latitudeAddress;

@property double longitudeAddress;

@end

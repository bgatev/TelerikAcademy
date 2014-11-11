//
//  AppDelegate.m
//  try2
//
//  Created by admin on 10/26/14.
//  Copyright (c) 2014 admin. All rights reserved.
//
#import <Parse/Parse.h>
#import "AppDelegate.h"
#import <GoogleMaps/GoogleMaps.h>
#import "ViewPromosController.h"
#import <AVFoundation/AVFoundation.h>
#include <AudioToolbox/AudioToolbox.h>

@interface AppDelegate ()

@end

@implementation AppDelegate

@synthesize window = _window;

@synthesize myAudioPlayer;


- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
    // Override point for customization after application launch.
    [Parse setApplicationId:@"5z3CuJA6ymo6Vnz7tOLzXVhiVpa9b7Boq8keDPa5"
                  clientKey:@"QaF2ATJDO2d8vtDR9h021zS0SkRDyTC6NBPBvwgf"];
    
    [PFAnalytics trackAppOpenedWithLaunchOptions:launchOptions];
    
    [GMSServices provideAPIKey:@"AIzaSyDOheUrLTIh6kh1OX9m6EV2BxdG5mtAVNQ"];
    
    
    //start a background sound
    NSString *soundFilePath = [[NSBundle mainBundle] pathForResource:@"ATC" ofType: @"mp3"];
    NSURL *fileURL = [[NSURL alloc] initFileURLWithPath:soundFilePath ];
    myAudioPlayer = [[AVAudioPlayer alloc] initWithContentsOfURL:fileURL error:nil];
    myAudioPlayer.numberOfLoops = -1; //infinite loop
    [myAudioPlayer play];

    
    return YES;
}

- (void)applicationWillResignActive:(UIApplication *)application {
    // Sent when the application is about to move from active to inactive state. This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) or when the user quits the application and it begins the transition to the background state.
    // Use this method to pause ongoing tasks, disable timers, and throttle down OpenGL ES frame rates. Games should use this method to pause the game.
}

- (void)applicationDidEnterBackground:(UIApplication *)application {
    // Use this method to release shared resources, save user data, invalidate timers, and store enough application state information to restore your application to its current state in case it is terminated later.
    // If your application supports background execution, this method is called instead of applicationWillTerminate: when the user quits.
}

- (void)applicationWillEnterForeground:(UIApplication *)application {
    // Called as part of the transition from the background to the inactive state; here you can undo many of the changes made on entering the background.
}

- (void)applicationDidBecomeActive:(UIApplication *)application {
    // Restart any tasks that were paused (or not yet started) while the application was inactive. If the application was previously in the background, optionally refresh the user interface.
}

- (void)applicationWillTerminate:(UIApplication *)application {
    // Called when the application is about to terminate. Save data if appropriate. See also applicationDidEnterBackground:.
}

//Accelerometer
- (void)applicationDidFinishLaunching:(UIApplication *)application {
    
    application.applicationSupportsShakeToEdit = YES;
    
   // [window addSubview:viewController.view];
    [self.window makeKeyAndVisible];
}

@end

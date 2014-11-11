//
//  AppDelegate.h
//  try2
//
//  Created by admin on 10/26/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <UIKit/UIKit.h>
#import <AVFoundation/AVFoundation.h>
#include <AudioToolbox/AudioToolbox.h>

@interface AppDelegate : UIResponder <UIApplicationDelegate>
{
    AVAudioPlayer *myAudioPlayer;
}

@property (nonatomic, retain) AVAudioPlayer *myAudioPlayer;

@property (strong, nonatomic) UIWindow *window;




@end


//
//  ViewController.m
//  try2
//
//  Created by admin on 10/26/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "ViewController.h"
#import "AppDelegate.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    self.view.backgroundColor=[UIColor colorWithPatternImage:[UIImage imageNamed:@"13.3.jpg"]];
    
    [self.soundBool setOnTintColor:[UIColor orangeColor]];
    [self.soundBool addTarget:self action:@selector(setState:) forControlEvents:UIControlEventValueChanged];
    
    
    [super viewDidLoad];
    
    if ([self.soundBool isOn]) {
        [self startMusic];
    }
    else
    {
        [self stopMusic ];
    }

}

- (void)setState:(id)sender
{
    BOOL state = [sender isOn];
    
    if (state == YES) {
        [self startMusic];
    }
    else{
        [self stopMusic];
    }
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)swipeBackLeft:(UIStoryboardSegue *)segue {
    
    
}

- (IBAction)swipeBackRight:(UIStoryboardSegue *)otherSegue {
    
    
}
- (IBAction)tapBackFromMap:(UIStoryboardSegue *)mapSegue {
    
    
}

- (IBAction)stopMusic
{
    AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
    [appDelegate.myAudioPlayer stop];
}


- (IBAction)startMusic
{
    AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
    [appDelegate.myAudioPlayer play];
}

@end

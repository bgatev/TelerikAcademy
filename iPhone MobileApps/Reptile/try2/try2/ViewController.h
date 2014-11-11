//
//  ViewController.h
//  try2
//
//  Created by admin on 10/26/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController

- (IBAction)swipeBackLeft:(UIStoryboardSegue *)segue;

- (IBAction)swipeBackRight:(UIStoryboardSegue *)otherSegue;

- (IBAction)tapBackFromMap:(UIStoryboardSegue *)mapSegue;

@property (weak, nonatomic) IBOutlet UISwitch *soundBool;

@end


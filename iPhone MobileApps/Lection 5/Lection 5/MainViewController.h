//
//  MainViewController.h
//  Lection 5
//
//  Created by BGatevMac on 11/2/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MainViewController : UIViewController
@property (weak, nonatomic) IBOutlet UITextField *password;
@property (weak, nonatomic) IBOutlet UITextField *code;
- (IBAction)addPassword:(id)sender;

@end

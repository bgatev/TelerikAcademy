//
//  MainViewController.m
//  Lection 5
//
//  Created by BGatevMac on 11/2/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "MainViewController.h"
#import "Password.h"

@interface MainViewController ()

@end

@implementation MainViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

- (IBAction)addPassword:(id)sender {
    Password *newPass = [[Password alloc] initWithName:self.password.text andCode:self.code.text];
    
    
    
    UIAlertView *view = [[UIAlertView alloc] initWithTitle:newPass.accName
                                                   message: newPass.encrCode
                                                  delegate:nil cancelButtonTitle:@"OK"
                                         otherButtonTitles:nil, nil];
    
    [view show];
}

@end

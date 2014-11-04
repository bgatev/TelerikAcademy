//
//  CreateListViewController.h
//  NotesList
//
//  Created by admin on 11/1/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MainViewController.h"
#import "NotesList.h"

@interface CreateListViewController : UIViewController
@property (weak, nonatomic) IBOutlet UITextField *listTitleLabel;
@property (weak, nonatomic) IBOutlet UITextField *listCategoryLabel;
- (IBAction)addListTouchUp:(id)sender;

@end

//
//  AddNoteViewController.h
//  NotesList
//
//  Created by admin on 11/1/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Note.h"
#import "ListDetailsViewController.h"

@interface AddNoteViewController : UIViewController
@property (weak, nonatomic) IBOutlet UITextField *noteTitleInputLabel;
@property (weak, nonatomic) IBOutlet UITextView *noteContentInputLabel;
- (IBAction)addNoteTouchUp:(id)sender;

@end

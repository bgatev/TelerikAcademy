//
//  ListDetailsViewController.h
//  NotesList
//
//  Created by admin on 11/1/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "NotesList.h"
#import "Note.h"
#import "AddNoteViewController.h"

@interface ListDetailsViewController : UIViewController<UITableViewDataSource,UITableViewDataSource>
@property (weak, nonatomic) IBOutlet UILabel *titleOutputLabel;

@property (weak, nonatomic) IBOutlet UILabel *categoryOutputLabel;

@property (weak, nonatomic) IBOutlet UITableView *notesTableView;

@property (nonatomic) NotesList *notesList;

@end

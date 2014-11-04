//
//  ViewController.h
//  NotesList
//
//  Created by admin on 10/30/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "ListData.h"
#import "NotesList.h"
#import "ListDetailsViewController.h"

@interface MainViewController : UIViewController<UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UITableView *tableView;

@property (nonatomic) ListData *listData;

@end


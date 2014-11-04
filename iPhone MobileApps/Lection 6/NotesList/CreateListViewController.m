//
//  CreateListViewController.m
//  NotesList
//
//  Created by admin on 11/1/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "CreateListViewController.h"


@interface CreateListViewController ()

@end

#define trimAll(object)[object stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]]

@implementation CreateListViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.title = @"Create List";
    // Do any additional setup after loading the view.
    
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

- (IBAction)addListTouchUp:(id)sender {
    UIAlertView *alert;
    
    NSString *listTitle = self.listTitleLabel.text;
    NSString *listCategory = self.listCategoryLabel.text;
    
    if ([trimAll(listTitle) length] == 0 || [trimAll(listTitle) length] > 40) {
        alert = [[UIAlertView alloc] initWithTitle:@"Error" message:@"Title must be between 1 and 40 symbols" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles:nil, nil];
        [alert show];
    }
    else if([trimAll(listCategory) length] == 0 || [trimAll(listCategory) length] > 40){
        alert = [[UIAlertView alloc] initWithTitle:@"Error" message:@"Category must be between 1 and 40 symbols" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles:nil, nil];
        [alert show];
    }
    else{
        //hide keyboard
        [self.listTitleLabel resignFirstResponder];
        [self.listCategoryLabel resignFirstResponder];
        
        //clear inputs
        self.listTitleLabel.text = @"";
        self.listCategoryLabel.text = @"";
        
        MainViewController *mainViewController = [self.navigationController.viewControllers objectAtIndex:0];
        NotesList *newList = [[NotesList alloc] initWithTitle:listTitle andCategory:listCategory];
        
        [mainViewController.listData addList:newList];
        alert = [[UIAlertView alloc] initWithTitle:@"Success" message:@"Added list" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles:nil, nil];
        [alert show];
        [mainViewController.tableView reloadData];
    }
}

//hide keyboard when user clicks anywhere on the screen
-(void)touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event{
    [self.view endEditing:TRUE];
}
@end

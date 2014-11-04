//
//  AddNoteViewController.m
//  NotesList
//
//  Created by admin on 11/1/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "AddNoteViewController.h"

@interface AddNoteViewController ()

@end

#define trimAll(object)[object stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]]

@implementation AddNoteViewController

- (void)viewDidLoad {
    [super viewDidLoad];
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

- (IBAction)addNoteTouchUp:(id)sender {
    UIAlertView *alertView;
    
    NSString *noteTitle = self.noteTitleInputLabel.text;
    NSString *noteContent = self.noteContentInputLabel.text;
    if ([trimAll(noteTitle) length] == 0 || [trimAll(noteTitle) length] > 30) {
        alertView = [[UIAlertView alloc] initWithTitle:@"Error" message:@"Title must be between 1 and 30 symbols" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles:nil, nil];
        [alertView show];
    }
    else if([trimAll(noteTitle) length] == 0 || [trimAll(noteTitle) length] > 500){
        alertView = [[UIAlertView alloc] initWithTitle:@"Error" message:@"Content must be between 1 and 500 symbols" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles:nil, nil];
        [alertView show];
    }
    else{
        //hide keyboard
        [self.noteTitleInputLabel resignFirstResponder];
        [self.noteContentInputLabel resignFirstResponder];
        Note *newNote = [[Note alloc] initWithTitle:noteTitle andContent:noteContent];
        
        int previousControllerIndex = [self getPreviuousControllerIndex];
        ListDetailsViewController *controller = [self.navigationController.viewControllers objectAtIndex:previousControllerIndex];
        
        //add note
        [controller.notesList.notes addObject:newNote];
        alertView = [[UIAlertView alloc]  initWithTitle:@"Success" message:@"Note added!" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles:nil, nil];
        [alertView show];
        NSLog(@"NOTES:%lu",(unsigned long)[controller.notesList.notes count]);
        [controller.notesTableView reloadData];
    }
}

-(int) getPreviuousControllerIndex{
    NSArray *stack = self.navigationController.viewControllers;
    
    for (int i = (int)stack.count - 1; i >= 0; i--) {
        if (stack[i] == self) {
            return i - 1;
        }
    }
    
    return -1;
}

//hide keyboard when user clicks anywhere on the screen
-(void)touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event{
    [self.view endEditing:TRUE];
}
@end

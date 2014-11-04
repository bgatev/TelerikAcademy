//
//  ViewController.m
//  NotesList
//
//  Created by admin on 10/30/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "MainViewController.h"
#import "NoteListUITableViewCell.h"

@interface MainViewController (){
    
}

@end

@implementation MainViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.title = @"Notes List";
    
    //better done with synthesized property, only looking for the hard stuff
    [self.tableView reloadData];
    if (!self.listData) {
        self.listData = [[ListData alloc] init];
    }
    
    [self.tableView registerNib:[UINib nibWithNibName:@"NoteListTableViewCell" bundle:nil] forCellReuseIdentifier:@"Cell"];
    // Do any additional setup after loading the view, typically from a nib.
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender{
    if ([segue.identifier  isEqual: @"noteListDetailsSegue"]) {
        ListDetailsViewController *detailsController = [segue destinationViewController];
        NSIndexPath *path = [self.tableView indexPathForSelectedRow];
        
        NotesList *list = [self.listData getByIndex:path.row];
        
        [detailsController setNotesList:list];
    }
}

-(void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    [self performSegueWithIdentifier:@"noteListDetailsSegue" sender:nil];
}

-(BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath{
    return YES;
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath{
    
    static NSString *identifier = @"Cell";
    NoteListUITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:identifier];
    
    NotesList *currList = [self.listData getByIndex:indexPath.row];
    
    cell.titleLabel.text = currList.title;
    cell.categoryLabel.text = currList.category;
    
    return cell;
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section{
    return [self.listData count];
}

@end

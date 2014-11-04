//
//  PhotoTableViewController.m
//  SimplePhotoViewer
//
//  Created by admin on 10/26/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "PhotoTableViewController.h"

@interface PhotoTableViewController (){
    NSMutableArray *images;
}

@end

@implementation PhotoTableViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.title = @"Photos";
    
    images = [[NSMutableArray alloc] init];
    
    [self initializeImages];
    // Uncomment the following line to preserve selection between presentations.
    // self.clearsSelectionOnViewWillAppear = NO;
    
    // Uncomment the following line to display an Edit button in the navigation bar for this view controller.
    // self.navigationItem.rightBarButtonItem = self.editButtonItem;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    // Return the number of rows in the section.
    return images.count;
}

-(void)initializeImages{
    Image *img = [[Image alloc] init];
    [img setName:@"Ferrari Enzo"];
    [img setFileName:@"ferrari-enzo"];
    NSLog(@"%@",[img fileName]);
    [img setDetails:@"Rare model of Ferrari for members of the Ferarri official club"];
    
    [images addObject:img];
    
    img = [[Image alloc] init];
    [img setName:@"Lamborghini Diablo"];
    [img setFileName:@"lamborghini-diablo"];
    [img setDetails:@"One of the last Diablo's produced - the 2001 model with 6.0 V12 engine"];
    
    [images addObject:img];
    
    img = [[Image alloc] init];
    [img setName:@"Nissan GTR"];
    [img setFileName:@"nissan-gtr"];
    [img setDetails:@"The japanese supercar with very reasonable price"];
    
    [images addObject:img];
    
    img = [[Image alloc] init];
    [img setName:@"Pagani Zonda"];
    [img setFileName:@"pagani-zonda"];
    [img setDetails:@"The hand-made supercar masterpiece by Pagani. The construction is mainly of carbon-fiber"];
    
    [images addObject:img];
    
    img = [[Image alloc] init];
    [img setName:@"Rolls-Royce Wraith"];
    [img setFileName:@"rollsroyce-wraith"];
    [img setDetails:@"The luxury convertible from Rolls Royce. The name wraith comes from an old scottish word meaning Ghost of Spirit. It has V12 twin-turbo engine producing 623hp"];
    
    [images addObject:img];
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    static NSString *cellIdentifier = @"Cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellIdentifier forIndexPath:indexPath];
    
    Image *currentImage = [images objectAtIndex:indexPath.row];
    cell.textLabel.text = [currentImage name];
    
    // Configure the cell...
    
    return cell;
}


/*
// Override to support conditional editing of the table view.
- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the specified item to be editable.
    return YES;
}
*/

/*
// Override to support editing the table view.
- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        // Delete the row from the data source
        [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
    } else if (editingStyle == UITableViewCellEditingStyleInsert) {
        // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
    }   
}
*/

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath {
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/


#pragma mark - Navigation

 //In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
    
    DisplayViewController *viewController = [segue destinationViewController];
    NSIndexPath *path = [self.tableView indexPathForSelectedRow];
    Image *img = [images objectAtIndex:path.row];
    
    [viewController setImage:img];
    
}


@end

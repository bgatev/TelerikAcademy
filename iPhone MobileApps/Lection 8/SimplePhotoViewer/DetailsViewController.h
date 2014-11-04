//
//  DetailsViewController.h
//  SimplePhotoViewer
//
//  Created by admin on 10/26/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Image.h"


@interface DetailsViewController : UIViewController
@property (weak, nonatomic) IBOutlet UILabel *detailsLabel;

@property (nonatomic) Image *image;


@end

//
//  DisplayViewController.h
//  SimplePhotoViewer
//
//  Created by admin on 10/26/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Image.h"
#import "DetailsViewController.h"

@interface DisplayViewController : UIViewController
@property (weak, nonatomic) IBOutlet UIImageView *currentImage;

@property (nonatomic) Image *image;

@end

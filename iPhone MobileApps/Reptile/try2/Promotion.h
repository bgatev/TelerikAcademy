//
//  Promotion.h
//  PrImotsiyaApp
//
//  Created by admin on 11/9/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <Parse/Parse.h>

@interface Promotion : PFObject<PFSubclassing>

@property (nonatomic, strong) NSString * Name;
@property (nonatomic, strong) NSString * Category;
@property (nonatomic, strong) PFFile * Picture;
@property (nonatomic, strong) PFGeoPoint * Shop;
@property (nonatomic, strong) NSString * MoreInfo;
@property (nonatomic, strong) NSNumber * Price;


@end

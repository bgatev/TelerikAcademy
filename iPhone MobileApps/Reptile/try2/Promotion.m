//
//  Promotion.m
//  PrImotsiyaApp
//
//  Created by admin on 11/9/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "Promotion.h"

@implementation Promotion

@dynamic Name;

@dynamic Category;

@dynamic Picture;

@dynamic Shop;

@dynamic MoreInfo;

@dynamic Price;

+(NSString *)parseClassName{
    return @"Promotion";
}

+(void)load{
    [self registerSubclass];
}


@end

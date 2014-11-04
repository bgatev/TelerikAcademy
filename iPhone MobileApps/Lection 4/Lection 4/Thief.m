//
//  Thief.m
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "Thief.h"

@implementation Thief
-(id) init {
    self = [super init];
    if (self) {
        self.life = @90;
        [self addSkill:@"Bunny"];
    }
    
    return self;
}

@end

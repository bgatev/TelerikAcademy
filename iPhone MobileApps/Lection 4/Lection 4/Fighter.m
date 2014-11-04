//
//  Fighter.m
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "Fighter.h"

@implementation Fighter

-(id) init {
    self = [super init];
    if (self) {
        self.life = @100;
        [self addSkill:@"Master"];
    }
    
    return self;
}

@end

//
//  CTO.m
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "CTO.h"

@implementation CTO

-(id) init {
    self = [super init];
    if (self) {
        self.life = @22;
        [self addSkill:@"CTO"];
    }
    
    return self;
}
@end

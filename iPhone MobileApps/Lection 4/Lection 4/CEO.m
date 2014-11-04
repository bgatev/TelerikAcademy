//
//  CEO.m
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "CEO.h"

@implementation CEO
-(id) init {
    self = [super init];
    if (self) {
        self.life = @33;
        [self addSkill:@"CEO"];
    }
    
    return self;
}
@end

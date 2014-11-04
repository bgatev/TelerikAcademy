//
//  Bachkator.m
//  Lection 4
//
//  Created by BGatevMac on 10/29/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "Bachkator.h"

@implementation Bachkator

-(id) init {
    self = [super init];
    if (self) {
        self.life = @200;
        [self addSkill:@"Nema labavo"];
    }
    
    return self;
}
@end

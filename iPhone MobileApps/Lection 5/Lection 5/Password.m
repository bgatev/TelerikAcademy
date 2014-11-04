//
//  Password.m
//  Lection 5
//
//  Created by BGatevMac on 11/2/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "Password.h"

@implementation Password

-(instancetype) initWithName: (NSString *) name andCode: (NSString *) code {
    self = [super init];
    
    if (self) {
        self.accName = name;
        self.encrCode = code;
    }
    
    return self;
}

@end

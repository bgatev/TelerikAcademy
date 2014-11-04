//
//  Note.m
//  NotesList
//
//  Created by admin on 10/30/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "Note.h"

@implementation Note

-(id) initWithTitle:(NSString *)title andContent:(NSString *)content{
    self = [super self];
    if (self) {
        [self setTitle:title];
        [self setContent:content];
    }
    
    return self;
}
@end

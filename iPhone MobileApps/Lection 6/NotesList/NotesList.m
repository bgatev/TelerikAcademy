//
//  NotesList.m
//  NotesList
//
//  Created by admin on 10/30/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "NotesList.h"

@implementation NotesList

-(id)initWithTitle:(NSString *)title andCategory:(NSString *)category{
    self = [super self];
    
    if (self) {
        [self setTitle:title];
        [self setCategory:category];
        self.notes = [[NSMutableArray alloc] init];
    }
    
    return self;
}
@end

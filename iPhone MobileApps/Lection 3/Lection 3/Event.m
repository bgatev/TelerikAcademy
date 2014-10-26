//
//  Event.m
//  Lection 3
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "Event.h"

@implementation Event

@synthesize title = _title;
@synthesize category = _category;
@synthesize content = _content;
@synthesize date = _date;
@synthesize guests = _guests;

- (id) init {
    self = [super init];
    if (self) {
        
    }
    
    return self;
}

- (id) initWithTitle: (NSString *) title {
    self = [super init];
    if (self) {
        self.title = title;
        if (self.guests.count == 0) {
            self.guests = [[NSMutableArray alloc] init];
        }
    }
    
    return self;
}

- (NSString *) title {
    return _title;
}

- (void) setTitle: (NSString *) eventTitle {
    _title = eventTitle;
}

- (NSString *) category {
    return _category;
}

- (void) setCategory: (NSString *) eventCategory {
    _category = eventCategory;
}

- (NSString *) content {
    return _content;
}

- (void) setContent: (NSString *) eventContent {
    _content = eventContent;
}

- (NSDate *) date {
    return _date;
}

- (void) setDate: (NSDate *) eventDate {
    _date = eventDate;
}

- (NSMutableArray *) guests {
    return _guests;
}

- (void) addGuest: (NSString *) newGuest {
    [_guests addObject:newGuest];
}

- (NSString *) description {
    return [NSString stringWithFormat:@"Title: %@ Category: %@ Content: %@ Date: %@ Guests: %@", self.title, self.category, self.content, self.date, self.guests];
}

@end

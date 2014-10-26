//
//  EventManager.m
//  Lection 3
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "EventManager.h"
#import "Event.h"

@implementation EventManager

@synthesize allEvents = _allEvents;

- (id) init {
    self = [super init];
    if (self) {
        if (self.allEvents.count == 0) {
            self.allEvents = [[NSMutableArray alloc] init];
        }
    }
    
    return self;
}

- (void) createEvent: (NSMutableArray *) params {
    Event *newEvent = [[Event alloc] initWithTitle:params[0]];
    newEvent.category = params[1];
    newEvent.content = params[2];
    newEvent.date = params[3];
    for (NSString *guest in params[4]) {
        [newEvent addGuest:guest];
    }
    
    [self.allEvents addObject:newEvent];
}

- (void) listAllEvents {
    for (Event *singleEvent in self.allEvents) {
        NSLog(@"%@", singleEvent);
    }
}

- (void) listEventsByCategory: (NSString *) category {
    NSPredicate *catPredicate = [NSPredicate predicateWithFormat:@"SELF.category LIKE [c] %@", category];
    NSArray *result = [self.allEvents filteredArrayUsingPredicate:catPredicate];
    
    for (Event *singleEvent in result) {
        NSLog(@"%@", singleEvent);
    }
}

- (void) sortAllEventsByDate {
    NSSortDescriptor *dateDescriptor = [[NSSortDescriptor alloc] initWithKey:@"date" ascending: YES];
    NSMutableArray *sortDescriptors = [NSMutableArray arrayWithObject:dateDescriptor];
    NSArray *allEventsSorted = [self.allEvents sortedArrayUsingDescriptors:sortDescriptors];
    
    self.allEvents = [allEventsSorted mutableCopy];
}

- (void) sortAllEventsByTitle {
    NSSortDescriptor *dateDescriptor = [[NSSortDescriptor alloc] initWithKey:@"title" ascending: YES];
    NSMutableArray *sortDescriptors = [NSMutableArray arrayWithObject:dateDescriptor];
    NSArray *allEventsSorted = [self.allEvents sortedArrayUsingDescriptors:sortDescriptors];
    
    self.allEvents = [allEventsSorted mutableCopy];
}
@end

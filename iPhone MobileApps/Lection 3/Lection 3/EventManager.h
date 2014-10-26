//
//  EventManager.h
//  Lection 3
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface EventManager : NSObject

@property NSMutableArray *allEvents;

- (void) createEvent: (NSMutableArray *) params;
- (void) listAllEvents;
- (void) listEventsByCategory: (NSString *) category;
- (void) sortAllEventsByDate;
- (void) sortAllEventsByTitle;

@end

//
//  main.m
//  Lection 3
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "EventManager.h"

int main(int argc, const char * argv[])
{

    @autoreleasepool {
        NSString *dateString1 = @"26-11-2014";
        NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
        [dateFormatter setDateFormat:@"dd-MM-yyyy"];
        NSDate *date1 = [dateFormatter dateFromString:dateString1];
        
        NSMutableArray *guests1 = [[NSMutableArray alloc] init];
        [guests1 addObject:@"pesho1"];
        [guests1 addObject:@"gosho1"];
        
        NSMutableArray *eventParams1 = [[NSMutableArray alloc] init];
        [eventParams1 addObject:@"title1"];
        [eventParams1 addObject:@"cat1"];
        [eventParams1 addObject:@"content1"];
        [eventParams1 addObject:date1];
        [eventParams1 addObject:guests1];
        
        NSString *dateString2 = @"28-10-2014";
        NSDate *date2 = [dateFormatter dateFromString:dateString2];
        
        NSMutableArray *guests2 = [[NSMutableArray alloc] init];
        [guests2 addObject:@"pesho2"];
        [guests2 addObject:@"gosho2"];
        
        NSMutableArray *eventParams2 = [[NSMutableArray alloc] init];
        [eventParams2 addObject:@"I am title2"];
        [eventParams2 addObject:@"cat2"];
        [eventParams2 addObject:@"content2"];
        [eventParams2 addObject:date2];
        [eventParams2 addObject:guests2];
        
        EventManager *myManager = [[EventManager alloc] init];
        [myManager createEvent:eventParams1];
        [myManager createEvent:eventParams2];
        [myManager listAllEvents];
        
        [myManager listEventsByCategory:@"cat2"];
        
        [myManager sortAllEventsByDate];
        [myManager listAllEvents];
        
        [myManager sortAllEventsByTitle];
        [myManager listAllEvents];
        
    }
    
    return 0;
}


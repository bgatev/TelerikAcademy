//
//  Event.h
//  Lection 3
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Event : NSObject

- (id) initWithTitle: (NSString *) title;

@property (nonatomic, strong) NSString *title;
@property (nonatomic, strong) NSString *category;
@property (nonatomic, strong) NSString *content;
@property (nonatomic, strong) NSDate *date;
@property (nonatomic, strong) NSMutableArray *guests;

- (NSString *) title;
- (void) setTitle: (NSString *) eventTitle;
- (NSString *) category;
- (void) setCategory: (NSString *) eventCategory;
- (NSString *) content;
- (void) setContent: (NSString *) eventContent;
- (NSDate *) date;
- (void) setDate: (NSDate *) eventDate;
- (NSMutableArray *) guests;
- (void) addGuest: (NSString *) newGuest;

@end

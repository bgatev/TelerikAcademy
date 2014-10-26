//
//  ToDo.h
//  Lection 2
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface ToDo : NSObject

- (id) initWithName: (NSString *) toDoName;
- (id) initWithName: (NSString *) toDoName
         andEndDate: (NSDate *) toDoEndDate;

@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSDate *endDate;

+ (void) addTodo: (ToDo *) newToDo;
+ (void) listAllTodos;

@end

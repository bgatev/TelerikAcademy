//
//  ToDo.m
//  Lection 2
//
//  Created by BGatevMac on 10/26/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import "ToDo.h"

@implementation ToDo

@synthesize name = _name;
@synthesize endDate = _endDate;

NSMutableArray *allToDos;

- (id) init {
    self = [super init];
    if (self){
        self.name = @"";
        self.endDate = [[NSDate alloc] init];
        if (allToDos.count == 0) {
            allToDos = [[NSMutableArray alloc] init];
        }
    }
    
    return self;
}

- (id) initWithName: (NSString *) toDoName {
    self = [super init];
    if (self){
        self.name = toDoName;
        self.endDate = [[NSDate alloc] init];
        if (allToDos.count == 0) {
            allToDos = [[NSMutableArray alloc] init];
        }
    }
    
    return self;
}

- (id) initWithName: (NSString *) toDoName
         andEndDate: (NSDate *) toDoEndDate {
    self = [super init];
    if (self){
        self.name = toDoName;
        self.endDate = toDoEndDate;
        if (allToDos.count == 0) {
            allToDos = [[NSMutableArray alloc] init];
        }
    }
    
    return self;
}

-(NSString *) name {
    return _name;
}

-(void) setName: (NSString *) name {
    _name = name;
}

-(NSDate *) endDate {
    return _endDate;
}

+ (void) addTodo: (ToDo *) newToDo {
    [allToDos addObject:newToDo];
}

+ (void) listAllTodos {
    for(ToDo *singleToDo in allToDos){
        NSLog(@"%@", singleToDo);
    }
}

- (NSString *) description {
    return [NSString stringWithFormat:@"%@ must be completed till %@", self.name, self.endDate];
}

@end

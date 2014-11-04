//
//  ListData.m
//  NotesList
//
//  Created by admin on 10/30/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "ListData.h"

@implementation ListData{
    NSMutableArray *notesLists;
}

-(id) init{
    self = [super self];
    if (self) {
        notesLists = [[NSMutableArray alloc] init];
    }
    
    return self;
}

-(NSUInteger) count{
    return [notesLists count];
}

-(void) addList:(NotesList *)list{
    [notesLists addObject:list];
}

-(NSMutableArray *) getAll{
    return notesLists;
}

-(NotesList *) getByIndex:(NSUInteger)index{
    if (index > 0 && index < [notesLists count]) {
        return [notesLists objectAtIndex:index];
    }
    else{
        return nil;
    }
}

-(void) removeList:(NotesList *)list{
    [notesLists removeObject:list];
}

-(void) removeListByTitle:(NSString *)title{
    NSPredicate *predicate = [NSPredicate predicateWithFormat:@"SELF.title=%@",title];
    NSArray *filteredList = [notesLists filteredArrayUsingPredicate:predicate];
    
    notesLists = [filteredList mutableCopy];
}

-(NotesList *) getByTitle:(NSString *) title{
    for (int i = 0; i < [notesLists count]; i++) {
        if ([[[notesLists objectAtIndex:i] title] isEqualToString:title]) {
            return [notesLists objectAtIndex:i];
        }
    }
    
    return nil;
}
@end

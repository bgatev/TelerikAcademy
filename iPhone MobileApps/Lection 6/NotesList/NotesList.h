//
//  NotesList.h
//  NotesList
//
//  Created by admin on 10/30/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Note.h"

@interface NotesList : NSObject{
    //NSMutableArray *_notes;
}

-(id) initWithTitle:(NSString *) title andCategory:(NSString *) category;

@property (nonatomic) NSString *title;

@property (nonatomic) NSString *category;

@property (nonatomic) NSMutableArray *notes;

@end

//
//  Note.h
//  NotesList
//
//  Created by admin on 10/30/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Note : NSObject

-(id) initWithTitle: (NSString *) title andContent:(NSString *) content;

@property (nonatomic) NSString *title;

@property (nonatomic) NSString *content;

@end

//
//  Password.h
//  Lection 5
//
//  Created by BGatevMac on 11/2/14.
//  Copyright (c) 2014 BGatevMac. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Password : NSObject

-(instancetype) initWithName: (NSString *) name andCode: (NSString *) code;

@property NSString *accName;
@property NSString *encrCode;
@end

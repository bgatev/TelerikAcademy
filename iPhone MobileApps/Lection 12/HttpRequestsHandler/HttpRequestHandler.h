//
//  HttpRequestHandler.h
//  HttpRequestsHandler
//
//  Created by admin on 11/4/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface HttpRequestHandler : NSObject<NSURLConnectionDelegate>

-(void) get:(NSString *) url
withHeaders:(NSDictionary *) headers;

-(void) post: (NSString *) url
        data: (NSData *) data
 withHeaders: (NSDictionary *) headers;

@end

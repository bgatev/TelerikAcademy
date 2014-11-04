//
//  main.m
//  HttpRequestsHandler
//
//  Created by admin on 11/4/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "HttpRequestHandler.h"

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        NSMutableDictionary *headers = [[NSMutableDictionary alloc] init];
        
        [headers setValue:@"application/json" forKey:@"Content-type"];
        
        HttpRequestHandler *handler = [[HttpRequestHandler alloc] init];
        
        [handler get:@"http://google.com" withHeaders:headers];
    }
    return 0;
}

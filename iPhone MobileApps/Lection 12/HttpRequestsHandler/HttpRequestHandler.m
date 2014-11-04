//
//  HttpRequestHandler.m
//  HttpRequestsHandler
//
//  Created by admin on 11/4/14.
//  Copyright (c) 2014 admin. All rights reserved.
//

#import "HttpRequestHandler.h"

@implementation HttpRequestHandler{
    NSMutableData *_data;
}

-(void) get:(NSString *)urlStr withHeaders:(NSDictionary *)headers{
    
    NSURL *url = [NSURL URLWithString:urlStr];
    
    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:url];
    [request setAllHTTPHeaderFields:headers];
    
    //NSURLConnection *connection = [[NSURLConnection alloc] initWithRequest:request delegate:self];
    
    NSHTTPURLResponse *response = nil;
    NSError *error = nil;
    
    [NSURLConnection sendSynchronousRequest:request returningResponse:&response error:&error];
    
    NSLog(@"%@",response);
    
}

-(void) post:(NSString *)url data:(NSData *)data withHeaders:(NSDictionary *)headers{
    NSURL *urlStr = [NSURL URLWithString:url];
    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:urlStr];
    
    [request setAllHTTPHeaderFields:headers];
    [request addValue:@"application/json" forHTTPHeaderField:@"Content-type"];
    request.HTTPBody = data;
    request.HTTPMethod = @"POST";
    
    NSHTTPURLResponse *response = nil;
    NSError *error = nil;
    
    [NSURLConnection sendSynchronousRequest:request returningResponse:&response error:&error];
    
    NSLog(@"%@",response);
    
}

-(void)connection:(NSString *)connection didReceiveData:(NSData *)data{
    [_data appendData:data];
}

-(void)connection:(NSURLConnection *)connection didFailWithError:(NSError *)error{
    NSLog(@"Connection failed! %@",[error localizedDescription]);
}

@end

# Overview

A big clunky GUI to let non-programmers query large sets of similarly-formatted 
JSON documents, particularly those downloaded from an AWS S3 bucket.

Programmers could do this more efficiently by just using 
[awscli](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/index.html)
and [jq](https://stedolan.github.io/jq/),
but people interested in business analytics often won't be comfortable with those
tools.

The IDEAL end-state would be a web GUI, hosted on AWS, allowing users to point-
and-click to specify filter criteria and fields to extract, letting the majority
of the S3 I/O and processing run internally on their data center, and then 
generating an extract file when processing completes (probably itself posted to a
different S3 bucket, with a download link emailed to the requesting user).

And that would be a neatly encapsulated work-egg to contract out to an AWS web 
developer.

Think of this utility as a stop-gap measure, used in part to demonstrate and 
refine the eventual cloud GUI and extract report format we'd like built.

## Backlog

- support grouping (parentheses), "AND" and "OR" on filters (perhaps via "ANY", "ALL")

## Changelog

- see [Changelog](README_CHANGELOG.md)

# Overview

A simple GUI to let non-programmers query large sets of JSON documents, 
whether stored on a filesystem or downloaded from an AWS S3 bucket.

Programmers can generate ad-hoc queries using 
[awscli](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/index.html)
and [jq](https://stedolan.github.io/jq/),
but many people interested in business or data analytics won't be comfortable 
with those tools, and may prefer a flat CSV export they can readily load into
Excel for crosstabs and charting.

## What this is Not

The *ideal* end-state for S3-backed data would be a web application, hosted 
natively on AWS, allowing users to point-and-click to specify filter criteria and
fields to extract, letting the majority of the S3 I/O and processing run 
internally on their data center, and then generating an extract file when 
processing completes (probably itself posted to a different S3 bucket, with a 
download link emailed to the requesting user).

And that would be a neatly encapsulated work-egg to contract out to an AWS web 
developer. You may consider this utility as a stop-gap measure, used to 
demonstrate and refine the eventual cloud GUI and report-builder interface you'd
like to provision.

## What this Is

Given the above, is this throwaway code, a wasted effort?

*It is not.* The truth is that many smaller shops *don't have* a cloud developer, 
or cloud-backed data, (or schedule / budget to create a bespoke tool), but do 
have a big pile of JSON documents they'd like to sift through.  And it kind of 
blew my mind that on a quick Google search, I couldn't find a basic, free Windows
GUI letting business users do that.

So now there is one :-)

# Backlog

- save/load configs (filter and extract sets)
- before/after comparator for dates
- progressBar for extract, sync

# Changelog

- see [Changelog](README_CHANGELOG.md)

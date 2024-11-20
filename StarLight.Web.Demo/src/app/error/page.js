"use client";
import React from 'react';
import { Typography } from '@mui/material';
import useSWR from 'swr'
import DemoGraph from '@/components/smart/demo-graph';
import LoadingPage from '@/components/dumb/loading';
import ErrorMessage from '@/components/dumb/error';

const fetcher = async url => {
    const res = await fetch(url)
   
    // If the status code is not in the range 200-299,
    // we still try to parse and throw it.
    if (!res.ok) {
      const error = new Error('An error occurred while fetching the data.')
      // Attach extra info to the error object.
      error.status = res.status
      throw error
    }
   
    return res.json()
  }

const ErrorPage = () => {
  const { data, error, isLoading } = useSWR('/api/pricesslows', fetcher)

  if (isLoading) return <LoadingPage></LoadingPage>
  if (error) return <ErrorMessage error={error}></ErrorMessage>

  return (
    <>
      <Typography variant='h2' component="h1" gutterBottom>
        Error Example</Typography>
      <DemoGraph graphData={data.data}></DemoGraph>
    </>
  );
};

export default ErrorPage;
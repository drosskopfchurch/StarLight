"use client";
import React from 'react';
import { Typography } from '@mui/material';
import useSWR from 'swr'
import DemoGraph from '@/components/smart/demo-graph';
import LoadingPage from '@/components/dumb/loading';

const fetcher = (url) => fetch(url).then((res) => res.json());

const SlowPage = () => {
  const { data, error, isLoading } = useSWR('/api/pricesslow', fetcher)

  if (isLoading || !data) return <LoadingPage>Loading Slow Example</LoadingPage>
  if (error) return <ErrorMessage error={error}></ErrorMessage>

  return (
    <>
      <Typography variant='h2' component="h1" gutterBottom>
        Slow Example</Typography>
      <DemoGraph graphData={data.data}></DemoGraph>
    </>
  );
};

export default SlowPage;
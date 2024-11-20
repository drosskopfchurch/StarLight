"use client";
import LoadingPage from '@/components/dumb/loading';
import DemoGraph from '@/components/smart/demo-graph';
import { Typography } from '@mui/material';
import React from 'react';
import useSWR from 'swr'

const fetcher = (url) => fetch(url).then((res) => res.json());


const RegularPage = () => {
  const { data, error, isLoading } = useSWR('/api/prices', fetcher)


  if (isLoading) return <LoadingPage></LoadingPage>
  if (error) return <ErrorMessage error={error}></ErrorMessage>

  return (
    <>
      <Typography variant='h2' component="h1" gutterBottom>
      Regular Example</Typography>
      <DemoGraph graphData={data.data}></DemoGraph>
    </>
  );
};

export default RegularPage;